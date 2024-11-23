# TILO

<a href="https://sites.google.com/view/7tilo-xtilo/home">7TILO website</a>

## Overview
TILO is a collection of Computer Science excercises

## Projects

### 1. **Turing Machine for Addition**
   This project implements a single-tape Turing machine that performs binary addition of two numbers.

   **Key Features:**
   - The machine operates on a binary string that includes two numbers separated by a `+` symbol.
   - The Turing machine processes the binary input and outputs the sum of the two binary numbers.
   - Designed to follow the traditional rules of a Turing machine, including reading, writing, and moving along the tape.

   **Example:**
   - Input: `101 + 11`
   - Output: `1000` (5 + 3 = 8 in binary)

### 2. **Multiple Tape Turing Machine**
   This project demonstrates a more complex, multitape Turing machine, which can operate simultaneously on multiple tapes to increase efficiency for specific tasks.

   **Key Features:**
   - Multiple tapes allow for parallel processing, reducing the number of steps required for complex computations.
   - Each tape operates independently, but they interact through the machine’s control mechanism.
   - This implementation can be extended to handle more sophisticated tasks than a single-tape machine.

   **Use Cases:**
   - Suitable for more complex algorithms that require the division of tasks across tapes.
   - Can be applied to more advanced operations such as multiplication or language recognition problems in computational theory.

### 3. Binary Comparison Function (foo)

This project implements a Turing machine that compares two binary numbers `x` and `y` and returns `1` if `x > y`, and `0` otherwise.

#### Function Definition
- **foo(x, y)**: Outputs `1` if `x > y`; otherwise, outputs `0`.
- **Inputs**: Two binary numbers separated by `+` (e.g., `x+y`).
- **Alphabet**: `{0, 1, +}`.

#### Steps
1. **Design the Turing Machine for Comparison**: Define the Turing machine’s states and transitions to compare two binary numbers separated by `+`.
2. **Implement Transition Functions**: Write the specific transition rules needed to perform the comparison operation.
3. **Enhanced Simulation Features**:
   - **Custom Simulation**: Simulate the comparison Turing machine created in step 1.
   - **Binary Encoding of Turing Machines**: Allow encoding of machine structure in binary format for easy interpretation by the simulator.
   - **Binary Code Conversion**: Convert binary-coded Turing machine structures into a format usable by the simulator.

### 4. Graph Traversal

This program evaluates nodes in a weighted, connected graph with edges requiring resources to traverse. The goal is to maximize resource gain (`z`) while adhering to a set budget (`r`).

### Problem Description
- **Input:** A graph of evaluated nodes connected by weighted edges.
- **Output:** For each step `t`, the program outputs the state `r`, `z`, along with the edge and node used

### 5. **Minimum Spanning Tree Algorithms**
Implementation and comparison of Kruskal's, Jarnik's (Prim's), and Borůvka's algorithms to find the MST of a graph.
