package com.pathfinder.pathfinder_api.controller;

import com.pathfinder.pathfinder_api.Models.Course;
import com.pathfinder.pathfinder_api.Models.Learnership;
import com.pathfinder.pathfinder_api.repository.CourseRepository;
import com.pathfinder.pathfinder_api.repository.LearnershipRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/admin")
public class AdminController {

    @Autowired
    private CourseRepository courseRepository;

    @Autowired
    private LearnershipRepository learnershipRepository;

    @PostMapping("/courses")
    public Course addCourse(@RequestBody Course course) {
        return courseRepository.save(course);
    }

    @PostMapping("/learnerships")
    public Learnership addLearnership(@RequestBody Learnership learnership) {
        return learnershipRepository.save(learnership);
    }
}
