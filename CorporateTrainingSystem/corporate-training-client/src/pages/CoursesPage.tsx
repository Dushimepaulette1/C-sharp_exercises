import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import type { TrainingCourse } from "../types/TrainingCourse";
import { getCourses } from "../services/courseService";

function CoursesPage() {
  const [courses, setCourses] = useState<TrainingCourse[]>([]);

  useEffect(() => {
    getCourses().then((data) => setCourses(data));
  }, []);

  return (
    <div>
      <h1>Corporate Training System</h1>
      {courses.map((course) => (
        <div key={course.id}>
          <h2>
            <Link to={`/courses/${course.id}`}>{course.title}</Link>
          </h2>
          <p>{course.description}</p>
          <p>Instructor: {course.instructor}</p>
        </div>
      ))}
    </div>
  );
}

export default CoursesPage;
