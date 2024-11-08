**Table name**:
- first letter is uppercase
- underscore separation between words
exemples: User_Activity, User_Account, User_Count

**Column name**:
- all lowercase
- underscore separation between words
exemples: id, full_name, created_on, password_hash
- foreign keys (table references), table name + column name
exemples: User_Account_id

**Dates**:
- Timestamps: context + at
exemples: updated_at, created_at, deleted_at
- Dates: context + on
exemples: updated_on, created_on, deleted_on, performed_on, approved_on

**Attribution**:
-  context + by
exemples: approved_by, authored_by, performed_by, sended_by, created_by, last_modified_by

**Updates**:
- Last + Midified + extension (by, on)
-exemples: last_modified_by, last_modified_on

**General Rules**:
- column name can't have table name in it (can be dedused)
exemple: table User_Account column user_name = User.user_name :'(
- column name can't have abbreviation except for normes
exemples: 