import { useParams, useNavigate } from "react-router-dom";

const courses = [
  {
    id: 1,
    title: "React JS Fundamentals",
    category: "Frontend",
    duration: "5 Days",
    trainer: "Geetha",
    description: "Learn components, props, state, events, and routing in React.",
    image: "https://images.unsplash.com/photo-1633356122102-3fe601e05bd2?w=600&h=300&fit=crop&crop=center"
  },
  {
    id: 2,
    title: "ASP.NET Core Web API",
    category: "Backend",
    duration: "6 Days",
    trainer: "Kumar",
    description: "Build RESTful APIs with ASP.NET Core and Entity Framework.",
    image: "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=600&h=300&fit=crop&crop=center"
  },
  {
    id: 3,
    title: "Full Stack Development",
    category: "Full Stack",
    duration: "10 Days",
    trainer: "Priya",
    description: "Complete full stack development with React and ASP.NET Core.",
    image: "https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=600&h=300&fit=crop&crop=center"
  }
];

function CourseDetails() {
  const { courseId } = useParams();
  const navigate = useNavigate();

  const course = courses.find(c => c.id === Number(courseId));

  if (!course) {
    return (
      <div className="page">
        <h2>Course not found</h2>
        <button className="btn" onClick={() => navigate("/courses")}>Back to Courses</button>
      </div>
    );
  }

  return (
    <div className="page detail-page">
      <img src={course.image} alt={course.title} className="detail-img" />
      <div className="detail-body">
        <span className="detail-category">{course.category}</span>
        <h2>{course.title}</h2>
        <p className="detail-trainer">Trainer: {course.trainer}</p>
        <p className="detail-duration">{course.duration}</p>
        <p className="detail-desc">{course.description}</p>
        <button className="btn" onClick={() => navigate("/courses")}>← Back to Courses</button>
      </div>
    </div>
  );
}

export default CourseDetails;
