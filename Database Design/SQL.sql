CREATE TABLE `users` (
  `id` integer PRIMARY KEY,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(255) NOT NULL
);

CREATE TABLE `tasks` (
  `id` integer PRIMARY KEY,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `user_id` int NOT NULL,
  `createdAt` datetime DEFAULT 'CURRENT_TIMESTAMP'
);

CREATE TABLE `task_comments` (
  `id` integer PRIMARY KEY,
  `task_id` int NOT NULL,
  `user_id` int NOT NULL,
  `comment_text` text NOT NULL,
  `createdAt` datetime DEFAULT 'CURRENT_TIMESTAMP'
);

ALTER TABLE `tasks` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `task_comments` ADD FOREIGN KEY (`task_id`) REFERENCES `tasks` (`id`);

ALTER TABLE `task_comments` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
