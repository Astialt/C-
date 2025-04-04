using System;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace OrderManagement.Services
{
    public class NotificationService
    {
        private const string MapName = "OrderNotifications";
        private const int MapSize = 1024;

        public void WriteNotification(string notification)
        {
            using (var mmf = MemoryMappedFile.CreateOrOpen(MapName, MapSize))
            {
                using (var accessor = mmf.CreateViewAccessor())
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(notification);
                    accessor.Write(0, messageBytes.Length);
                    accessor.WriteArray(4, messageBytes, 0, messageBytes.Length);
                }
            }
        }

        public string ReadNotification()
        {
            using (var mmf = MemoryMappedFile.OpenExisting(MapName))
            {
                using (var accessor = mmf.CreateViewAccessor())
                {
                    int length = accessor.ReadInt32(0);
                    byte[] messageBytes = new byte[length];
                    accessor.ReadArray(4, messageBytes, 0, length);
                    return Encoding.UTF8.GetString(messageBytes);
                }
            }
        }
    }
}
