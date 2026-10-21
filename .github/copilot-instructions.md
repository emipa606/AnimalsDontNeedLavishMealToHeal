# GitHub Copilot Instructions for "Animals Don't Need Lavish Meal To Heal (Continued)" Mod

## Mod Overview and Purpose

**Mod Name:** Animals Don't Need Lavish Meal To Heal (Continued)  
**Original Creator:** Sielfyr  
**Maintainer:** Mlie  
**Package ID:** Mlie.AnimalsDontNeedLavishMealToHeal

This mod aims to simplify the logistics of caring for your animals in RimWorld by preventing colonists from feeding lavish meals to wounded animals. The mod offers a tailored solution for players who want to manage their animal care without compromising the availability of high-value meals.

### Purpose

- **Target Audience**: Players who want to manage animal care logistics efficiently.
- **Primary Functionality**: Restricts the type of food colonists feed to patient animals, thereby saving lavish meals for colonists and allowing better rationing of resources.

## Key Features and Systems

### Features

1. **Custom Food Restriction**:
   - Introduces a food restriction rule that applies to patient animals.
   - Default restriction is named "VetFoodRestriction," and users can rename it if necessary.

2. **Integration with RimWorld UI**:
   - Integrates with RimWorld's food restriction menu.
   - Adds a quick-access shortcut in the animal management menu for easy handling.

3. **Compatibility**:
   - Compatible with existing save files (can enable/disable without issues).
   - Relies on the vanilla food restriction menu, so mods interfering with this menu might cause conflicts.

## Coding Patterns and Conventions

- **C# Naming Conventions**:
  - Follows PascalCase for class names and camelCase for method arguments and local variables.
  - Uses descriptive names for classes and methods to enhance readability.

- **XML Configuration**:
  - Follows a clear and minimalist structure for easy integration with game settings.
  - Comments and tags are used to maintain clarity and support future extensions if required.

## XML Integration

- **File**: `About.xml` is the primary configuration file.
- **Dependencies**: Ensures the use of `brrainz.harmony` to manage dynamic patching and overriding of game methods.
- **Structure**: The XML is parsed using a tree-sitter for efficient data handling and parsing.

## Harmony Patching

The mod employs Harmony for method patching, crucial to seamlessly integrating new behaviors without altering the game’s original codebase. The following patching strategy is applied:

- **HarmonyPatches Folder**:
  - Contains patches like `FoodRestrictionDatabase_ExposeData`, `FoodRestrictionDatabase_TryDelete`, and `FoodUtility_WillEat_Thing`.

- **Patch Types**:
  - **Prefix Methods**: Used to execute code before target method execution, allowing for input validation and restriction setup.
  - **Postfix Methods**: Ensures that changes are applied after the normal execution, modifying the aftermath (example: how patient animals are fed).

- **Common Patterns**:
  - Use of `Instance` and careful management of state within patches to ensure no side effects on the vanilla game logic.

## Suggestions for Copilot

- **Implement a Configuration System**: Suggest ways to extend the mod by offering custom configuration options for users (e.g., GUI-based settings menu).
- **Enhanced Compatibility Checks**: Provide code snippets for detecting compatibility conflicts with other mods automatically.
- **Optimization Ideas**: Recommend efficient loops and data structures Copilot can suggest to handle large groups of animals to avoid performance issues.
- **Animal Feeding Logic**: Suggest extensions to current feeding logic, such as prioritizing leftover or low-quality meals over better meals for feeding/hunting distant animals.

---

Following these guidelines and insights will help you or contributors efficiently extend or maintain the "Animals Don't Need Lavish Meal To Heal (Continued)" mod while ensuring high compatibility and quality of code structure.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

