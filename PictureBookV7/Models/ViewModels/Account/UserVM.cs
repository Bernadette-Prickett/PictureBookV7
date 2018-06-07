// ***********************************************************************
// Assembly         : PictureBookV7
// Author           : Bernie
// Created          : 06-07-2018
//
// Last Modified By : Bernie
// Last Modified On : 06-07-2018
// ***********************************************************************
// <copyright file="UserVM.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PictureBookV7.Models.ViewModels.Account
{
    /// <summary>
    /// Class UserVM.
    /// </summary>
    public class UserVM
    {
        //Getters and Setters with Data Annotations
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [Required]
        public string ConfirmPassword { get; set; }

        //Empty Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVM"/> class.
        /// </summary>
        public UserVM()
        {
        }

        //Overloaded Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVM"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        public UserVM(UserDTO row)
        {
            Id = row.Id;
            FirstName = row.FirstName;
            LastName = row.LastName;
            EmailAddress = row.EmailAddress;
            Username = row.Username;
            Password = row.Password;
        }


    }
}