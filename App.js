import React from "react";
import StudentTable from "./components/StudentTable";
import "./App.css";
function App() {
  const students = [
    { name: "Kohinoor Tiwari", math: 80, science: 89, english: 85 },
    { name: "Rajveer Singh", math: 70, science: 65, english: 75 },
    { name: "Rashi Jain", math: 90, science: 88, english: 92 },
    { name: "Karan Aujla", math: 60, science: 70, english: 75 },
    { name: "Khushi Kapoor", math: 85, science: 78, english: 78 },
    { name: "Harshit Pathak", math: 56, science: 78, english: 65 },
    { name: "Champa Kumari", math: 78, science: 82, english: 89 },
    { name: "Hania Amir", math: 92, science: 88, english: 94 },
    { name: "Nishchay Malhan", math: 66, science: 70, english: 72 },
    { name: "Kunika Sharma", math: 88, science: 90, english: 86 }
  ];

  return (
    <div className="App">
      <h1>Student Marks Table</h1>
      <StudentTable data={students} />
    </div>
  );
}

export default App;
 