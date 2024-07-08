package com.pathfinder.pathfinder_api.repository;

import com.pathfinder.pathfinder_api.Models.StudentMarks;
import org.springframework.data.jpa.repository.JpaRepository;

public interface StudentMarksRepository extends JpaRepository<StudentMarks, Long> {
}