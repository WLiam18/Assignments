import { useNavigate } from "react-router-dom";

function NotFound() {
  const navigate = useNavigate();

  return (
    <div className="page not-found">
      <h2>404 - Page Not Found</h2>
      <p>The page you are looking for does not exist.</p>
      <button className="btn" onClick={() => navigate("/")}>Go to Home</button>
    </div>
  );
}

export default NotFound;
