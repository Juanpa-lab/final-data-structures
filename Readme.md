Hero’s Quest
Overview
Hero’s Quest is a C# console-based fantasy adventure game. The player explores a world of connected rooms, faces stat-based challenges, and tries to reach the exit without running out of health.

Hero
Stats: Strength, Agility, Intelligence, Health (starts at 20)

Inventory: Queue (max 5 items), starts with "Sword" and "Health Potion"

Map (Graph)
15+ rooms connected as a graph

Some paths require specific stats or items

One room is marked as the exit with a valid path guaranteed (verified using BFS)

Challenges (BST)
Stored in a binary search tree by difficulty (1–20)

Types: Combat, Trap, Puzzle

Challenges require certain stats or items

On failure, health is reduced by the stat difference

Challenge node is removed after completion

Data Structures Used
Graph – for the map

Binary Search Tree – for challenges

Queue – for inventory

Stack – for tracking visited rooms and treasures (in second half)

Dictionary – for fast room data lookup

Time Complexity
BST Search: O(log n) average, O(n) worst

Graph Traversal (BFS): O(V + E)

Queue Operations: O(1)