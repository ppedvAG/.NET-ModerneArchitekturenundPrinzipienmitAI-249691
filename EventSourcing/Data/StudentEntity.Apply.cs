using EventSourcing.Events;

namespace EventSourcing.Data;

public partial class StudentEntity : IMaterializable
{

    private void Apply(StudentRegisteredEvent ev)
    {
        if (ev != null)
        {
            Id = ev.StudentId;
            FullName = ev.FullName;
            Email = ev.Email;
            DateOfBirth = ev.DateOfBirth;
        }
    }

    private void Apply(StudentEmailUpdatedEvent ev)
    {
        if (ev?.StudentId == Id)
        {
            Email = ev.Email;
        }
    }

    private void Apply(StudentEnrolledEvent ev)
    {
        if (ev?.StudentId == Id)
        {
            EnrolledCourses.Add(ev.CourseName);
        }
    }

    private void Apply(StudentDisenrolledEvent ev)
    {
        if (ev?.StudentId == Id)
        {
            EnrolledCourses.Remove(ev.CourseName);
        }
    }

    public void Apply(DomainEvent ev)
    {
        switch (ev)
        {
            case StudentRegisteredEvent studentRegisteredEvent:
                Apply(studentRegisteredEvent);
                break;
            case StudentEmailUpdatedEvent studentEmailUpdatedEvent:
                Apply(studentEmailUpdatedEvent);
                break;
            case StudentEnrolledEvent studentEnrolledEvent:
                Apply(studentEnrolledEvent);
                break;
            case StudentDisenrolledEvent studentDisenrolledEvent:
                Apply(studentDisenrolledEvent);
                break;
            default:
                break;
        }
    }
}