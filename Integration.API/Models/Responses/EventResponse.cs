using Integration.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Integration.API.Responses
{
    public class EventResponse
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [JsonProperty("changeKey")]
        public string ChangeKey { get; set; }

        [JsonProperty("categories")]
        public List<object> Categories { get; set; }

        [JsonProperty("transactionId")]
        public object TransactionId { get; set; }

        [JsonProperty("originalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonProperty("originalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonProperty("iCalUId")]
        public string ICalUId { get; set; }

        [JsonProperty("reminderMinutesBeforeStart")]
        public int ReminderMinutesBeforeStart { get; set; }

        [JsonProperty("isReminderOn")]
        public bool IsReminderOn { get; set; }

        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("bodyPreview")]
        public string BodyPreview { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("sensitivity")]
        public string Sensitivity { get; set; }

        [JsonProperty("isAllDay")]
        public bool IsAllDay { get; set; }

        [JsonProperty("isCancelled")]
        public bool IsCancelled { get; set; }

        [JsonProperty("isOrganizer")]
        public bool IsOrganizer { get; set; }

        [JsonProperty("responseRequested")]
        public bool ResponseRequested { get; set; }

        [JsonProperty("seriesMasterId")]
        public object SeriesMasterId { get; set; }

        [JsonProperty("showAs")]
        public string ShowAs { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("webLink")]
        public string WebLink { get; set; }

        [JsonProperty("onlineMeetingUrl")]
        public object OnlineMeetingUrl { get; set; }

        [JsonProperty("isOnlineMeeting")]
        public bool IsOnlineMeeting { get; set; }

        [JsonProperty("onlineMeetingProvider")]
        public string OnlineMeetingProvider { get; set; }

        [JsonProperty("allowNewTimeProposals")]
        public bool AllowNewTimeProposals { get; set; }

        [JsonProperty("occurrenceId")]
        public object OccurrenceId { get; set; }

        [JsonProperty("isDraft")]
        public bool IsDraft { get; set; }

        [JsonProperty("hideAttendees")]
        public bool HideAttendees { get; set; }

        [JsonProperty("responseStatus")]
        public StatusResponse ResponseStatus { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("start")]
        public Time Start { get; set; }

        [JsonProperty("end")]
        public Time End { get; set; }

        [JsonProperty("location")]
        public LocationResponse Location { get; set; }

        [JsonProperty("locations")]
        public List<LocationResponse> Locations { get; set; }

        [JsonProperty("recurrence")]
        public object Recurrence { get; set; }

        [JsonProperty("attendees")]
        public List<AttendeeResponse> Attendees { get; set; }

        [JsonProperty("organizer")]
        public OrganizerResponse Organizer { get; set; }

        [JsonProperty("onlineMeeting")]
        public object OnlineMeeting { get; set; }

        [JsonProperty("calendar@odata.associationLink")]
        public string CalendarOdataAssociationLink { get; set; }

        [JsonProperty("calendar@odata.navigationLink")]
        public string CalendarOdataNavigationLink { get; set; }
    }
}