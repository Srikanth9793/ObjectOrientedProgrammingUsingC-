# OOP in C# — The Four Pillars (Theory)

This document explains the **four pillars of Object-Oriented Programming (OOP)** in clear, practical terms for C#.  
You’ll find plain-English definitions, simple analogies, real-life use cases, best practices, and common pitfalls.

---

## Table of Contents
- [What is OOP?](#what-is-oop)
- [1) Encapsulation](#1-encapsulation)
- [2) Abstraction](#2-abstraction)
- [3) Inheritance](#3-inheritance)
- [4) Polymorphism](#4-polymorphism)
- [Encapsulation vs Abstraction](#encapsulation-vs-abstraction)
- [Composition over Inheritance](#composition-over-inheritance)
- [SOLID Cheat-Sheet](#solid-cheat-sheet)
- [Real-Life Use Cases](#real-life-use-cases)
- [C# Idioms & Tips](#c-idioms--tips)
- [Common Pitfalls](#common-pitfalls)
- [Quick Review Checklist](#quick-review-checklist)
- [Glossary](#glossary)

---

## What is OOP?
OOP models software as **objects** that bundle **data** (state) with **behavior** (methods).  
Benefits: readability, reuse, testability, and the ability to evolve systems without breaking everything.

---

## 1) Encapsulation
**Definition:** Hide internal data and expose **controlled** operations. Keep invariants safe inside the type.

**Analogy:** A **bank account**—you can deposit/withdraw, but you can’t edit the database row yourself.

**You’ll use it to:**
- Validate inputs before changing state.
- Prevent illegal states (e.g., negative balance).
- Expose only what outside code needs.

**Best practices (C#):**
- Make fields `private` by default.
- Use properties for controlled access (`get; private set;`).
- Return read-only views (`IReadOnlyList<T>`).
- Validate in constructors/factories; keep objects always-valid.

**Where it shows up in real systems:**
- Domain entities (Account, Order) protecting invariants.
- Repositories/services that restrict how data can be changed.
- Public APIs that hide internal storage and schema.

---

## 2) Abstraction
**Definition:** Expose **what** something does and hide **how** it does it. Focus on the essential features.

**Analogy:** A **car’s pedals and wheel**—you can drive without understanding the engine.

**You’ll use it to:**
- Define contracts with `abstract` classes or `interface`s.
- Decouple callers from implementation details.
- Swap implementations without touching calling code.

**Best practices (C#):**
- Define small, focused interfaces (`ISP` from SOLID).
- Keep public surface areas minimal and intention-revealing.
- Prefer dependency inversion: depend on interfaces.

**Where it shows up in real systems:**
- `ILogger`, `IEmailSender`, `IPaymentGateway`, `IRepository<T>`.
- Libraries/frameworks exposing simple APIs over complex internals.
- Microservices exposing HTTP contracts while hiding databases.

---

## 3) Inheritance
**Definition:** A class **reuses and extends** behavior from a base class. Creates a type hierarchy.

**Analogy:** A **family tree**—children inherit traits, then add their own.

**You’ll use it to:**
- Share stable, truly common behavior across a hierarchy.
- Provide default logic in a base class and specialize in derived types.

**Best practices (C#):**
- Be conservative: **prefer composition** unless there’s a clear “is-a” relationship.
- Mark members `virtual` only when extension is intended; otherwise keep them non-virtual.
- Seal classes (`sealed`) by default if you don’t plan for inheritance.

**Where it shows up in real systems:**
- UI frameworks (Control → Button/TextBox).
- ASP.NET controllers inheriting from framework base classes.
- Custom exceptions inheriting from `Exception`.

---

## 4) Polymorphism
**Definition:** “Many forms.” Call the **same operation** on different types and get type-specific behavior.

**Analogy:** A **universal remote**—the “Power” button works for TV, AC, and projector, but each reacts differently.

**Types in C#:**
- **Runtime polymorphism**: `virtual`/`override` (or abstract) methods chosen at runtime.
- **Compile-time polymorphism**: method overloads chosen by signature at compile time (less about OOP design).

**You’ll use it to:**
- Write code against a base type or interface and plug in many implementations.
- Replace `switch`/`if` ladders with object behavior.

**Best practices (C#):**
- Program to interfaces/abstractions.
- Keep dispatch logic inside the objects (open for extension).
- Use DI to select implementations at composition root.

**Where it shows up in real systems:**
- Multiple logging providers under `ILogger`.
- Multiple storage providers under `IFileStore`.
- Strategy pattern for pricing, discounts, routing, or serialization.

---

## Encapsulation vs Abstraction
- **Encapsulation**: protects **state** (how data is stored/validated).
- **Abstraction**: hides **complexity** (how operations are performed) behind a simple interface.

You’ll often use **encapsulation inside** a class and **abstraction outside** (what the world sees).

---

## Composition over Inheritance
- **Composition**: build types by **combining** smaller behaviors (has-a).
- **Inheritance**: extend a base type (is-a).
- Prefer composition for flexibility and testability; use inheritance for stable, natural hierarchies.

---

## SOLID Cheat-Sheet
- **S**ingle Responsibility: one reason to change.
- **O**pen/Closed: open to extend, closed to modify existing code.
- **L**iskov: derived types must be substitutable for base types.
- **I**nterface Segregation: many small interfaces > one large one.
- **D**ependency Inversion: depend on abstractions, not concretions.

---

## Real-Life Use Cases
- **Payments**: `IPaymentGateway` with Stripe/PayPal implementations (abstraction + polymorphism).
- **Notifications**: Email/SMS/Push all behind `INotificationService`.
- **Persistence**: `IRepository<T>` with EF Core, Dapper, or in-memory impls.
- **Pricing/Rules**: Strategy pattern for discounts, tax, routing.
- **Observability**: `ILogger` swapping console/file/cloud sinks without changing business code.
- **UI/Controls**: Common base control with specialized widgets (inheritance + polymorphism).

---

## C# Idioms & Tips
- Enable nullable reference types (`<Nullable>enable</Nullable>`).
- Use **immutable value objects** for domain values (`record`, readonly properties).
- Expose read-only collections (`IReadOnlyList<T>`).
- Keep constructors small; use factories for complex creation/validation.
- Throw specific exceptions (`ArgumentOutOfRangeException`, `InvalidOperationException`).
- Keep async truly async; accept `CancellationToken` in I/O-bound APIs.

---

## Common Pitfalls
- Public setters that break invariants (prefer private set or immutability).
- God classes that do everything (violates SRP).
- Overusing inheritance where composition fits better.
- Leaking mutable collections.
- Catch-and-ignore exceptions; wrap with context instead.
- Null-heavy APIs; avoid returning `null` collections.

---

## Quick Review Checklist
- Does each class have **one responsibility**?
- Are invariants protected (no invalid states)?
- Is the public API **minimal and intention-revealing**?
- Are you **depending on interfaces** rather than concretes?
- Can you **swap implementations** without touching callers?
- Did you choose **composition** unless inheritance is clearly natural?

---

## Glossary
- **Class**: blueprint for objects (state + behavior).
- **Object**: an instance of a class.
- **Interface**: a contract (what methods exist), no implementation.
- **Abstract class**: shared partial implementation + abstract members.
- **Virtual**/**Override**: enables runtime polymorphism.
- **Value Object**: immutable type defined by values, not identity.
- **Entity**: has identity; equality by ID.

---

> ✅ This repo contains examples demonstrating the four pillars.  
> Use this README to understand the **why**, then explore the code to see the **how**.

