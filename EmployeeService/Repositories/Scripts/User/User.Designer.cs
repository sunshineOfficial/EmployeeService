﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeService.Repositories.Scripts.User {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class User {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal User() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EmployeeService.Repositories.Scripts.User.User", typeof(User).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set password_hash = @passwordHash
        ///where id = @id;.
        /// </summary>
        internal static string ChangePassword {
            get {
                return ResourceManager.GetString("ChangePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into users (role, username, email, name, surname, password_hash, refresh_token, refresh_token_expired_after)
        ///values (@Role, @Username, @Email, @Name, @Surname, @PasswordHash, @RefreshToken, @RefreshTokenExpiredAfter)
        ///returning id;.
        /// </summary>
        internal static string Create {
            get {
                return ResourceManager.GetString("Create", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete
        ///from users
        ///where id = @id;.
        /// </summary>
        internal static string Delete {
            get {
                return ResourceManager.GetString("Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users;.
        /// </summary>
        internal static string GetAll {
            get {
                return ResourceManager.GetString("GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where id = @id;.
        /// </summary>
        internal static string GetById {
            get {
                return ResourceManager.GetString("GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where email = @login
        ///   or username = @login;.
        /// </summary>
        internal static string GetByLogin {
            get {
                return ResourceManager.GetString("GetByLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select id                          as Id,
        ///       role                        as Role,
        ///       username                    as Username,
        ///       email                       as Email,
        ///       name                        as Name,
        ///       surname                     as Surname,
        ///       password_hash               as PasswordHash,
        ///       refresh_token               as RefreshToken,
        ///       refresh_token_expired_after as RefreshTokenExpiredAfter
        ///from users
        ///where refresh_token = @refreshToken;.
        /// </summary>
        internal static string GetByRefreshToken {
            get {
                return ResourceManager.GetString("GetByRefreshToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set username = coalesce(@Username, username),
        ///    email    = coalesce(@Email, email),
        ///    name     = coalesce(@Name, name),
        ///    surname  = coalesce(@Surname, surname)
        ///where id = @Id;.
        /// </summary>
        internal static string Update {
            get {
                return ResourceManager.GetString("Update", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update users
        ///set refresh_token               = @refreshToken,
        ///    refresh_token_expired_after = @refreshTokenExpiredAfter
        ///where id = @Id;.
        /// </summary>
        internal static string UpdateRefreshToken {
            get {
                return ResourceManager.GetString("UpdateRefreshToken", resourceCulture);
            }
        }
    }
}
