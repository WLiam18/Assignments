import { Link } from "react-router-dom";

const courses = [
  {
    id: 1,
    title: "React JS Fundamentals",
    duration: "5 Days",
    trainer: "Geetha",
    description: "Learn components, props, state, events, and routing in React.",
    image: "https://images.unsplash.com/photo-1633356122102-3fe601e05bd2?w=400&h=220&fit=crop&crop=center"
  },
  {
    id: 2,
    title: "ASP.NET Core Web API",
    duration: "6 Days",
    trainer: "Kumar",
    description: "Build RESTful APIs with ASP.NET Core and Entity Framework.",
    image: "https://images.unsplash.com/photo-1627398242454-45a1465c2479?w=400&h=220&fit=crop&crop=center"
  },
  {
    id: 3,
    title: "Full Stack Development",
    duration: "10 Days",
    trainer: "Priya",
    description: "Complete full stack development with React and ASP.NET Core.",
    image: "https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=400&h=220&fit=crop&crop=center"
  }
];

function Courses() {
  return (
    <div className="page">
      <h2>Available Courses</h2>
      <div className="course-grid">
        {courses.map((course) => (
          <div className="course-card" key={course.id}>
            <div className="course-img-wrap">
              <img src={course.image} alt={course.title} className="course-img" />
              
            </div>
            <div className="course-body">
              <h3>{course.title}</h3>
              <p className="course-trainer">{course.trainer}</p>
              <div className="course-meta">
                <span>{course.duration}</span>
              </div>
              <Link to={`/courses/${course.id}`} className="btn">View Details</Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Courses;
