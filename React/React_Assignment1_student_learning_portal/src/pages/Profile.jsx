function Profile() {
  const user = JSON.parse(localStorage.getItem("user"));

  return (
    <div>
      <h3>Student Profile</h3>
      <p><strong>Name:</strong> {user?.name || "Student User"}</p>
      <p><strong>Email:</strong> {user?.email || "student@example.com"}</p>
      <p><strong>Course:</strong> React JS Fundamentals</p>
      <p><strong>Status:</strong> Active</p>
    </div>
  );
}

export default Profile;
