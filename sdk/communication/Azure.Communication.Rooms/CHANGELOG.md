# Release History

## 1.0.0-beta.2 (2023-05-17)

### Features Added
- Added new function `ListRooms` to list all created rooms by returning `Pageable<CommunicationRoom>`.
- Added pagination support for `GetParticipants` by returning `Pageable<RoomParticipant>`.

### Breaking Changes
- Changed: Replaced `AddParticipants` and `UpdateParticipants` with `AddOrUpdateParticipants`.
- Changed: Renamed `RoleType` to `ParticipantRole`.
- Changed: Renamed `CreatedOn` to `CreatedAt` in `CommunicationRoom`.
- Changed: `UpdateRoom` no longer accepts participant list as input.
- Removed: `RoomJoinPolicy`, all rooms are invite-only by default.
- Removed: `Participants` from `CommunicationRoom` class.


## 1.0.0-beta.1 (2022-08-10)
- Initial version of Azure Communication Services Rooms .NET SDK.
