# Issue Identification Generation Logic

## Goal

The goal of the issue identification generation logic is to create easily identifiable and unique identifiers for each issue in the project. This helps users in easier identification and search within the application.

## Implementation

1. **Creating ProjectIssueId**: Issue identification generation is done from the project name and the issue identifier (or the last issue identifier). For example, an identifier can be created from the project name and the issue number, such as "PRJ-001".

2. **Querying the Last Issue Identifier**: Before creating a new issue, the service checks the database to find the last issue in the project.

3. **Incrementing the Identifier**: One is added to the identifier assigned to the last issue to get the identifier for the new issue. For example, if the last issue identifier was "PRJ-005", then the new issue identifier will be "PRJ-006".

4. **Using the New Issue Identifier**: The identifier for the new issue is used to create the issue, and it is displayed to users through the UI.

## Benefits

- **Easy Identification and Search**: Unique identifiers help users easily identify and search for issues within the application.
- **Unique Identifiers**: The identifiers assigned to issues will be guaranteed unique and will not conflict with database identifiers.
- **User-Friendly Appearance**: The identifiers are easily interpretable and recognizable to users.

## Further Development Opportunities

- **Customization of Identifier Format**: The format of the issue identifier can be customized according to the project's needs.
- **Computerized Generation**: Automation processes can be set up for generating and managing issue identifiers.
- **Expansion to Other Entities**: The identification generation logic can be extended to other entities such as tasks or bug reports.

