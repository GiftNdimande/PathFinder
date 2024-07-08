package com.pathfinder.pathfinder_api.controller;


import com.pathfinder.pathfinder_api.Models.StudentMarks;
import  com.pathfinder.pathfinder_api.repository.StudentMarksRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/student")
public class StudentController {

    @Autowired
    private StudentMarksRepository studentMarksRepository;

    @PostMapping("/marks")
    public StudentMarks registerMarks(@RequestBody StudentMarks studentMarks) {
        return studentMarksRepository.save(studentMarks);
    }
}