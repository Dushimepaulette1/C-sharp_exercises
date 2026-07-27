import { useEffect, useState } from "react";
import type { TrainingCourse } from "./types/TrainingCourse";
import { getCourses } from "./services/courseService";

function App() {
  const [courses, setCourses] = useState<TrainingCourse[]>([]);

  useEffect(() => {
    getCourses().then((data) => {
      setCourses(data);
    });
  }, []);

  return (
    <div>
      <h1>Corporate Training System</h1>

      {courses.map((course) => (
        <div key={course.id}>
          <h2>{course.title}</h2>
          <p>{course.description}</p>
          <p>Instructor: {course.instructor}</p>
        </div>
      ))}
    </div>
  );
}

export default App;
