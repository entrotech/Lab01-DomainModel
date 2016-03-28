﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Domain
{
    public class Person
    {

        #region Fields

        private int _id;
        private string _salutation = String.Empty;
        private string _firstName = String.Empty;
        private string _middleName = String.Empty;
        private string _lastName = String.Empty;
        private string _suffix = String.Empty;
        private string _stageName = String.Empty;
        private DateTime? _dateOfBirth;
        private double? _height;
        private int _hairColorId;
        private int _eyeColorId;
        private List<Credit> _credits = new List<Credit>();

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Salutation
        {
            get { return _salutation; }
            set { _salutation = value ?? String.Empty; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value ?? String.Empty; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value ?? String.Empty; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value ?? String.Empty; }
        }

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value ?? String.Empty; }
        }

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public double? Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int HairColorId
        {
            get { return _hairColorId; }
            set { _hairColorId = value; }
        }

        public int EyeColorId
        {
            get { return _eyeColorId; }
            set { _eyeColorId = value; }
        }

        public List<Credit> Credits
        {
            get { return _credits; }
        }

        #endregion

        #region Computed Properties

        public string FirstLastName
        {
            get
            {
                return (
                        (FirstName ?? "")
                        + " " +
                        (LastName ?? "")
                    ).Trim();
            }
        }

        public string LastFirstName
        {
            get
            {
                var sb = new StringBuilder();
                var joinCharacter = "";

                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sb.Append(joinCharacter + LastName);
                    joinCharacter = ", ";
                }
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sb.Append(joinCharacter + FirstName);
                }
                return sb.ToString();
            }
        }

        public string FullName
        {
            get
            {
                var sb = new StringBuilder();
                var joinCharacter = "";

                if (!String.IsNullOrWhiteSpace(Salutation))
                {
                    sb.Append(joinCharacter + Salutation);
                    joinCharacter = " ";
                }
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    sb.Append(joinCharacter + FirstName);
                    joinCharacter = " ";
                }
                if (!String.IsNullOrWhiteSpace(MiddleName))
                {
                    sb.Append(joinCharacter + MiddleName);
                    joinCharacter = " ";
                }
                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    sb.Append(joinCharacter + LastName);
                    joinCharacter = " ";
                }
                if (!String.IsNullOrWhiteSpace(Suffix))
                {
                    if (sb.Length > 0) joinCharacter = ", ";
                    sb.Append(joinCharacter + Suffix);
                    joinCharacter = " ";
                }
                return sb.ToString();
            }
        }

        public int? Age
        {
            get
            {
                if (DateOfBirth.HasValue == false) return null;
                var today = DateTime.Today;
                int years = today.Year - DateOfBirth.Value.Year;
                if (
                    (DateOfBirth.Value.Date.Month > today.Month)
                    || (DateOfBirth.Value.Date.Month == today.Month
                        && DateOfBirth.Value.Date.Day > today.Day))
                {
                    years--;
                }
                return years >= 0 ? years : 0;
            }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return FirstLastName;
        }

        #endregion
    }
}