# Context

We are given a list of number (e.g. [1, 2, 3, 4, 5]) and we need to re-arrange these numbers in the list in order to pass pre-defined validation rules.


# Objective

Write an algorithm to sort a list of numbers in order to pass some rule validations


# Key Learnings

- Understand how the checking of the rules are decoupled from the actual implementation
- Structure of a unit test
- The importance of interfaces
- Understand NUnit [TestFixture] and [TestCase] attributes
- Understand "Verify" concept
- Writing clear and concise algorithms
- Write new validation rules
- Write performance tests
- Understand big-O notation and complexity analysis
- Performance profiling using PerfView

# Curriculum

- Lesson 1
    - Understand the structure of the solution
    - Read:
        - CollectionFacts.cs
        - The rules that are found in the "Rules" folder
- Lesson 2:
    - Write an algorithm to pass the validation rules
- Lesson 3:
    - Write more validation rules
- Lesson 4:
    - Write a completely new algorithm to pass the validation rules
    - You might have different ideas for different algorithms. That is find. Create a new method for each
        implementation so that you can compare them in the next lesson
- Lesson 5:
    - Create a new project inside the solution to store the implementation
        - i.e. decouple the implementation from the unit test project
        - We will end up with 2 projects. One for the implementation and the other for the test
- Lesson 5:
    - Write some performance tests to understand time complexity of algorithm as collections grow larger
- Lesson 6:
    - Improve performance tests to compare different algorithms with each other
- Lesson 7:
    - Improve the performance of the algorithms using PerfView
- Lesson 8:
    - Improve the performance of the validation rules using PerfView

# Module improvements

- Start with really simple validation rules in Lesson 1
    - Need to write some really simple ones (i.e. check all numbers are in ascending order.)
    - Encourage trainee to invent some simple ones and write the implementation to pass
- Use complex validation rules for Lesson 2
- Add code to skip some validation rules
- Add performance tests
- Try different implementations to compare
    - Brute force
    - Genetic algorithm
    - Other 3rd party libraries
- Add logging
- Introduce IoC concepts

# Tags

Algorithm, Performance