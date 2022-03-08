# Basic template

A template allowing for rapid development with one or many target types (e.g. Web API, Azure Function, AWS Lambda)

## Architecture

Process logic is kept initially in domain, with folder level encapsulation allowing for rapid refactoring with minimal impact on consuming layers.

Refactoring should follow Onion style architecture.

Registrations should follow suit, with lower level registrations grouped by type (e.g. repositories, services), and any larger implementation registrations wrapping around those. This means composite roots can just call .RegisterRepositories() or .RegisterMyLargeImplementation() allowing for quick swapping between registrations.