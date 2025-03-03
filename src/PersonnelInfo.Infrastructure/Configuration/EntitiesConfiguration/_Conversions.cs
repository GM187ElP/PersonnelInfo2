using PersonnelInfo.Core.Enums;
using PersonnelInfo.Shared.Exceptions.Infrastructure;
using System.Globalization;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration
{
    public class _Conversions
    {
        public static string GenderType2String(GenderType? gender = GenderType.NotSelected)
        {
            return gender switch
            {
                GenderType.Male => "آقای",
                GenderType.Female => "خانم",
                GenderType.NotSelected => "انتخاب نشده",
                _ => throw new NotImplementedException()
            };
        }
        public static GenderType String2GenderType(string? gender = "انتخاب نشده")
        {
            return gender switch
            {
                "آقای" => GenderType.Male,
                "خانم" => GenderType.Female,
                "انتخاب نشده" => GenderType.NotSelected,
                _ => throw new NotImplementedException()
            };
        }

        public static string WorkingStatus2String(WorkingStatusType? WorkingStatus = WorkingStatusType.Working)
        {
            return WorkingStatus switch
            {
                WorkingStatusType.Working => "سر کار",
                WorkingStatusType.Left => "ترک کار",
                WorkingStatusType.NotSelected => "انتخاب نشده",
                _ => throw new NotImplementedException()
            };
        }

        public static WorkingStatusType String2WorkingStatus(string? WorkingStatus = "انتخاب نشده")
        {
            return WorkingStatus switch
            {
                "سر کار" => WorkingStatusType.Working,
                "ترک کار" => WorkingStatusType.Left,
                "انتخاب نشده" => WorkingStatusType.NotSelected,
                _ => throw new NotImplementedException()
            };
        }

        public static string? Gregorian2Farsi(DateTime? gregorianDate, char delimiter)
        {
            if (gregorianDate == null) return null;
            var farsiCalendar = new PersianCalendar();
            if (gregorianDate < new DateTime(622, 3, 22)) throw new ArgumentOutOfRangeException();

            var date = (farsiCalendar.GetYear((DateTime)gregorianDate), farsiCalendar.GetMonth((DateTime)gregorianDate), farsiCalendar.GetDayOfMonth((DateTime)gregorianDate));
            return $"{date.Item1}{delimiter}{date.Item2:D2}{delimiter}{date.Item3:D2}";

        }

        public static DateTime? Farsi2Gregorian(string? farsiDate, char delimiter)
        {
            if (farsiDate == null) return null;
            var farsiCalendar = new PersianCalendar();
            string[] dateParts = farsiDate.Split(delimiter);
            if (dateParts.Length != 3) throw new WrongDateFormat("Invalid date format");
            var date = farsiCalendar.ToDateTime(
                int.TryParse(dateParts[0], out var year) ? year : throw new WrongDateFormat("Year"),
                int.TryParse(dateParts[1], out var month) ? month : throw new WrongDateFormat("Month"),
                int.TryParse(dateParts[2], out var day) ? day : throw new WrongDateFormat("Day"), 0, 0, 0, 0
               );
            return date;
        }

        public static string NoteType2String(NoteType type = NoteType.NotSelected)
        {
            return type switch
            {
                NoteType.Checque => "چک",
                NoteType.PromissionaryNote => "سفته",
                NoteType.NotSelected => "انتخاب نشده",
                _ => throw new NotImplementedException()
            };
        }

        public static NoteType String2NoteType(string type = "انتخاب نشده")
        {
            return type switch
            {
                "چک" => NoteType.Checque,
                "سفته" => NoteType.PromissionaryNote,
                "انتخاب نشده" => NoteType.NotSelected,
                _ => throw new NotImplementedException()
            };
        }
    }
}
