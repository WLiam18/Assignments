import { Routes, Route } from "react-router-dom";
import { useState, useEffect } from "react";
import MainLayout from "./layouts/MainLayout";
import ProtectedRoute from "./components/ProtectedRoute";
import Home from "./pages/Home";
import About from "./pages/About";
import Courses from "./pages/Courses";
import CourseDetails from "./pages/CourseDetails";
import Contact from "./pages/Contact";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import Profile from "./pages/Profile";
import MyCourses from "./pages/MyCourses";
import Settings from "./pages/Settings";
import NotFound from "./pages/NotFound";
import "./App.css";

function App() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const stored = localStorage.getItem("user");
    if (stored) setUser(JSON.parse(stored));
  }, []);

  const handleLogin = (userData) => {
    setUser(userData);
    localStorage.setItem("user", JSON.stringify(userData));
  };

  const handleLogout = () => {
    setUser(null);
    localStorage.removeItem("user");
  };

  return (
    <Routes>
      <Route path="/" element={<MainLayout user={user} onLogout={handleLogout} />}>
        <Route index element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="courses" element={<Courses />} />
        <Route path="courses/:courseId" element={<CourseDetails />} />
        <Route path="contact" element={<Contact />} />
        <Route path="login" element={<Login onLogin={handleLogin} />} />

        <Route path="dashboard" element={
          <ProtectedRoute user={user}>
            <Dashboard />
          </ProtectedRoute>
        }>
          <Route index element={<Profile />} />
          <Route path="profile" element={<Profile />} />
          <Route path="my-courses" element={<MyCourses />} />
          <Route path="settings" element={<Settings />} />
        </Route>

        <Route path="*" element={<NotFound />} />
      </Route>
    </Routes>
  );
}

export default App;
