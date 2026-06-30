import { useNavigate } from "react-router-dom";

function Contact() {
  const navigate = useNavigate();

  return (
    <div className="page">
      <h2>Contact Us</h2>
      <p><strong>Email:</strong> support@studentportal.com</p>
      <p><strong>Phone:</strong> 9876543210</p>
      <p><strong>Location:</strong> Chennai, India</p>
      <button className="btn contact-btn" onClick={() => navigate(-1)}>
        Go Back
      </button>
    </div>
  );
}

export default Contact;