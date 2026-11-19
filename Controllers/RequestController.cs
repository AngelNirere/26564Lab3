using Smart_match.Models;

namespace Smart_match.Controllers;

public class RequestController
{
    private readonly RequestRepository _requests = new();
    private readonly MatchRepository _matches = new();
    private readonly ProfileRepository _profiles = new();
    private readonly MentorRepository _mentors = new();
    private readonly NotificationRepository _notifications = new();

    public void SendRequest(int mentorId)
    {
        var user = AuthController.CurrentUser;
        if (user == null)
            throw new InvalidOperationException("You must log in first.");

        if (user.Role != "Mentee")
            throw new InvalidOperationException("Only mentees can send mentorship requests.");

        if (mentorId <= 0)
            throw new ArgumentException("Select a mentor first.");

        if (_requests.ExistsActive(user.Id, mentorId))
            throw new ArgumentException("You already have a pending or accepted request to this mentor.");

        _requests.Insert(new MentorshipRequest
        {
            MenteeId = user.Id,
            MentorId = mentorId
        });

        _notifications.Insert(mentorId, "New mentorship request from " + user.Name + ".");
    }

    public List<RequestRow> GetMyIncomingRequests()
    {
        var user = AuthController.CurrentUser;
        if (user == null || user.Role != "Mentor")
            throw new InvalidOperationException("Only mentors can view incoming requests.");

        return _requests.GetForMentor(user.Id);
    }

    public void Accept(int requestId)
    {
        var request = GetOwnPendingRequest(requestId);

        // check that the mentor still has room for another mentee
        var mentor = _mentors.GetActiveMentors().FirstOrDefault(m => m.MentorId == request.MentorId);
        if (mentor != null && mentor.CurrentMentees >= mentor.Profile.MaxMentees)
            throw new InvalidOperationException("You have reached your maximum number of mentees.");

        // calculate the match score from both profiles
        double score = 0;
        var menteeProfile = _profiles.GetByUserId(request.MenteeId);
        var mentorProfile = _profiles.GetByUserId(request.MentorId);
        if (menteeProfile != null && mentorProfile != null)
            score = MatchingService.Score(menteeProfile, mentorProfile);

        _matches.Insert(request.MenteeId, request.MentorId, score);
        _requests.UpdateStatus(requestId, "Accepted");

        _notifications.Insert(request.MenteeId,
            AuthController.CurrentUser!.Name + " accepted your mentorship request.");
    }

    public void Reject(int requestId)
    {
        var request = GetOwnPendingRequest(requestId);
        _requests.UpdateStatus(requestId, "Rejected");

        _notifications.Insert(request.MenteeId,
            AuthController.CurrentUser!.Name + " declined your mentorship request.");
    }

    // makes sure the request exists, belongs to the logged-in mentor and is still Pending
    private MentorshipRequest GetOwnPendingRequest(int requestId)
    {
        var user = AuthController.CurrentUser;
        if (user == null || user.Role != "Mentor")
            throw new InvalidOperationException("Only mentors can answer requests.");

        if (requestId <= 0)
            throw new ArgumentException("Select a request first.");

        var request = _requests.GetById(requestId);
        if (request == null)
            throw new ArgumentException("Request not found.");

        if (request.MentorId != user.Id)
            throw new InvalidOperationException("This request was not sent to you.");

        if (request.Status != "Pending")
            throw new ArgumentException("This request was already answered.");

        return request;
    }
}