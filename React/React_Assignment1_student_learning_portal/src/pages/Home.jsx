import { useNavigate } from "react-router-dom";

function Home() {
  const navigate = useNavigate();

  return (
    <div className="page">
      <h2>Welcome to Student Learning Portal</h2>
      <p>Learn React, Web API, and Full Stack Development from one place.</p>
      <div style={{ display: "flex", gap: "12px", marginTop: "20px", flexWrap: "wrap" }}>
        <button className="btn" onClick={() => navigate("/courses")}>View Courses</button>
        <button className="btn btn-secondary" onClick={() => navigate("/dashboard")}>Go to Dashboard</button>
      </div>
    </div>
  );
}

export default Home;
