import type { TrainingCourse } from "../types/TrainingCourse";

export async function getCourses(): Promise<TrainingCourse[]> {
  const response = await fetch("http://localhost:5207/api/courses");

  const courses = await response.json();

  return courses;
}
