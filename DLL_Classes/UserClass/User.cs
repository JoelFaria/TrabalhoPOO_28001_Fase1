using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
        public class User
        {
            public int Id { get; set; }  // Feito automaticamente pelo SQL Server
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public User(string nome, string email, string password)
            {
                this.Nome = nome;
                this.Email = email;
                this.Password = password;
            }

            public string nomeUser
            {
                get { return Nome; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new System.ArgumentException("Nome não pode ser vazio");
                    }
                Nome = value;
                }
            }
            public string emailUser
            {
                get { return Email; }
                set {

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new System.ArgumentException("Email não pode ser vazio");
                    }

                Email = value; 
                }
            }
            public string PasswordUser
            {
                get { return Password; }
                set {

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new System.ArgumentException("Password não pode ser vazio");
                    }
                Password = value; 
                }
            }
        }
    }

