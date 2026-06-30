import { Outlet, NavLink, useNavigate } from "react-router-dom";

function MainLayout({ user, onLogout }) {
  const navigate = useNavigate();

  const handleLogout = () => {
  if (window.confirm("Are you sure you want to logout?")) {
    onLogout();
    navigate("/login");
  }
};

  return (
    <div>
      <nav className="navbar">
        <h2>Student Portal</h2>
        <div className="nav-links">
          <NavLink to="/" className={({ isActive }) => isActive ? "active" : ""} end>Home</NavLink>
          <NavLink to="/about" className={({ isActive }) => isActive ? "active" : ""}>About</NavLink>
          <NavLink to="/courses" className={({ isActive }) => isActive ? "active" : ""}>Courses</NavLink>
          <NavLink to="/contact" className={({ isActive }) => isActive ? "active" : ""}>Contact</NavLink>
          {!user && <NavLink to="/login" className={({ isActive }) => isActive ? "active" : ""}>Login</NavLink>}
          {user && <NavLink to="/dashboard" className={({ isActive }) => isActive ? "active" : ""}>Dashboard</NavLink>}
          {user && <button className="logout-btn" onClick={handleLogout}>Logout</button>}
        </div>
      </nav>
      <div className="container">
        <Outlet />
      </div>
    </div>
  );
}

export default MainLayout;
