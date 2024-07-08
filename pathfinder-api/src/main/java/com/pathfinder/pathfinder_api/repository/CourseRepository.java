package com.pathfinder.pathfinder_api.repository;


import com.pathfinder.pathfinder_api.Models.Course;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CourseRepository extends JpaRepository<Course, Long> {
}