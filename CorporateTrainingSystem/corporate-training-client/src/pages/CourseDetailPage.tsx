import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import type { TrainingCourse } from "../types/TrainingCourse";
import { getCourse } from "../services/courseService";

function CourseDetailPage() {
  const { id } = useParams<{ id: string }>();
  const [course, setCourse] = useState<TrainingCourse>();

  useEffect(() => {
    if (id) {
      getCourse(Number(id)).then((data) => setCourse(data));
    }
  }, [id]);

  if (!course) {
    return <p>Loading...</p>;
  }

  return (
    <div>
      <Link to="/courses">Back to courses</Link>
      <h1>{course.title}</h1>
      <p>{course.description}</p>
    </div>
  );
}

export default CourseDetailPage;
