import type { TrainingCourse } from "../types/TrainingCourse";

export async function getCourses(): Promise<TrainingCourse[]> {
  const response = await fetch("http://localhost:5207/courses");

  const courses = await response.json();

  return courses;
}

export async function getCourse(id: number): Promise<TrainingCourse> {
  const res = await fetch(`http://localhost:5207/courses/${id}`);
  const course = await res.json();
  return course;
}
