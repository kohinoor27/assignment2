import React from "react";

function StudentTable({ data }) {
  return (
    <table border="1" cellPadding="10" cellSpacing="0">
      <thead>
        <tr>
          <th>Name</th>
          <th>Math</th>
          <th>Science</th>
          <th>English</th>
          <th>Total</th>
          <th>Percentage</th>
        </tr>
      </thead>
      <tbody>
        {data.map((student, index) => {
          const total = student.math + student.science + student.english;
          const percentage = (total / 300) * 100;

          return (
            <tr key={index}>
              <td>{student.name}</td>
              <td>{student.math}</td>
              <td>{student.science}</td>
              <td>{student.english}</td>
              <td>{total}</td>
              <td>{percentage.toFixed(2)}%</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

export default StudentTable;
