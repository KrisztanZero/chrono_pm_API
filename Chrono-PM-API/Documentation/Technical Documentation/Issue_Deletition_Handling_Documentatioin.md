# Issue Deletion Handling Documentation

## Introduction
This document outlines the handling of issue deletion in the Chrono_PM_API application. When an issue is deleted, its associated comments need to be deleted as well. This document presents two alternative approaches for handling this scenario.

## Approach 1: Retry Deletion
In this approach, when an issue is deleted, the system attempts to delete each associated comment. If any comments fail to delete on the first attempt, the system retries the deletion process for those comments. If all comments are successfully deleted, the issue is then removed from the database.

### Pros:
- Automated retry mechanism ensures thorough deletion of associated comments.
- Simplifies error handling as the system automatically retries deletion.

### Cons:
- May result in longer execution time if multiple retries are required.
- May lead to potential issues if there are persistent problems with comment deletion.

## Approach 2: Return Unsuccessful Deletions
In this approach, when an issue is deleted, the system attempts to delete each associated comment. If any comments fail to delete, the system returns a list of IDs corresponding to the comments that were not successfully deleted. The issue is still removed from the database.

### Pros:
- Provides visibility into which comments failed to delete.
- Allows for manual intervention to resolve deletion issues.

### Cons:
- Requires manual intervention to address unsuccessful deletions.
- May lead to inconsistencies if manual intervention is not performed promptly.

## Conclusion
Both approaches offer different strategies for handling issue deletion and associated comment deletion. The choice between the two approaches depends on factors such as system performance requirements, error handling preferences, and the likelihood of deletion failures. It is recommended to evaluate these factors and choose the approach that best fits the application's needs.
