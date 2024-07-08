package com.pathfinder.pathfinder_api.repository;

import com.pathfinder.pathfinder_api.Models.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import com.pathfinder.pathfinder_api.Models.Role;
@Repository
public interface UserRepository extends JpaRepository<User, Long> {
    User findByUsername(String username);
}



