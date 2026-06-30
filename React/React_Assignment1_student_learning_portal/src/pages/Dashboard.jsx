import { Outlet, Link } from "react-router-dom";

function Dashboard() {
  return (
    <div className="page">
      <h2>Welcome to Student Dashboard</h2>
      <div className="dashboard-menu">
        <Link to="/dashboard/profile">Profile</Link>
        <Link to="/dashboard/my-courses">My Courses</Link>
        <Link to="/dashboard/settings">Settings</Link>
      </div>
      <div className="dashboard-content">
        <Outlet />
      </div>
    </div>
  );
}

export default Dashboard;
