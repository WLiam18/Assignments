import { useState } from "react";
import { useNavigate } from "react-router-dom";

function Login({ onLogin }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    setError("");

    if (!username.trim()) {
      setError("Username is required");
      return;
    }
    if (!password.trim()) {
      setError("Password is required");
      return;
    }
    if (username !== "student" || password !== "student123") {
      setError("Invalid username or password");
      return;
    }

    onLogin({ username, name: "Student User", email: "student@example.com" });
    navigate("/dashboard");
  };

  return (
    <div className="page">
      <h2>Login</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        {error && <div className="error">{error}</div>}
        <div>
          <label>Username</label>
          <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
        </div>
        <div>
          <label>Password</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </div>
        <button type="submit" className="btn" style={{ width: "100%" }}>Login</button>
      </form>
    </div>
  );
}

export default Login;
