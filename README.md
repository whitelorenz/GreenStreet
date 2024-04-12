# QA Automation Tester

## The Brief

A developer was given the following task:


> Write C# code to process a collection of string values which are passed to a method which returns a collection of processed strings. The input strings may be any length and can contain any character. Output strings must not be null or empty string, should be truncated to max length of 15 chars, and contiguous duplicate characters in the same case should be reduced to a single character in the same case. Dollar sign ($) should be replaced with a pound sign (£), and underscores (_) and number 4 should be removed. Code should be test-driven, efficient, re-usable and loosely coupled. The returned collection must not be null.
>
> Example input string:  AAAc91%cWwWkLq$1ci3_848v3d__K

Your task is to write a set of tests around the developers work to prove it has been suitably done to the given specifications.

## The Solution

The solution is a set of C# library projects. These projects contain the developers implementation and a placeholder project for unit tests.

The unit test project  has the following NuGet packages already installed to facilitate writing tests:
- NUnit
- Moq
- Shouldly

The solution has no runnable component (e.g. cannot press F5) and is expected to be run through the Test Runner.

## Submission

Submission of your solution should be as a link to a GitHub, or other Git-based, repo that we are able to access and clone for review.


null returns null
empty returns null
greater than 15 returns 15
equals to 15 returns 15
less than 15 returns same length
contiguos duplicates in the same case should be reduced to single char of the same case
contiguos duplicates of different case should be kept as they are
$ should be replaced to £
_ should be removed
4 should be removed
test all conditions at the same time should.and...

AAAc$1%4cWwWkL_q$1ci3_848v3d__K

Ac£1%cWwWkLq£1c
Ac£1%cWwWkLq£1ci3_848v3d__K