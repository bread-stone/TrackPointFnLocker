using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace TrackPointFnLocker {
    class Admin {
        public static bool hasPrivilege() {
            bool isAdmin;
            WindowsIdentity user = null;
            try {
                user = WindowsIdentity.GetCurrent(); // 현재 로그인된 user의 정보 
                if (user == null)
                    throw new InvalidOperationException("Couldn't get the current user identity");
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            } catch (UnauthorizedAccessException ex) {
                isAdmin = false;
            } catch (Exception ex) {
                isAdmin = false;
            } finally {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }


    }
}
