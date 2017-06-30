## Children's Game

### Mechanics

- _n_ children stand around a circle
- Starting with a given child and working clockwise, each child gets a sequential
  number, which we will refer to as its id.
- Then starting with the first child, they count out from 1 until _k_. The _k_'th
  child is now out and leaves the circle. The count starts again with the child
  immediately next to the eliminated one.
- Children are so removed from the circle one by one. The winner is the last child
  left standing.

### Prerequisites

You need to install the following software to build and run the app:

- [.NET Core runtime](https://www.microsoft.com/net/download/core)
- [Docker](https://www.docker.com/community-edition)

### Usage

Execute `./build.sh` to build the app, and `docker-compose up` to run.
