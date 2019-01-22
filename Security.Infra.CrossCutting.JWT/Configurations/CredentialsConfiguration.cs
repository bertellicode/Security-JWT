﻿using System.Text;
using Microsoft.IdentityModel.Tokens;
using Security.Infra.CrossCutting.JWT.Interfaces;

namespace Security.Infra.CrossCutting.JWT.Configurations
{
    public class CredentialsConfiguration : ICredentialsConfiguration
    {
        private const string SecretKeySigningCredentials = "sgstribanco@identityToken";

        private const string SecretKeyEncryptingCredentials = "ProEMLh5x_qnzdNU";

        public SymmetricSecurityKey SymmetricKeySigningCredentials => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKeySigningCredentials));

        public SymmetricSecurityKey SymmetricKeyEncryptingCredentials => new SymmetricSecurityKey(Encoding.Default.GetBytes(SecretKeyEncryptingCredentials));

        public SigningCredentials SigningCredentials { get; }

        public EncryptingCredentials EncryptingCredentials { get; }

        public CredentialsConfiguration(SigningCredentials signingCredentials)
        {
            SigningCredentials = new SigningCredentials(SymmetricKeySigningCredentials, SecurityAlgorithms.HmacSha256);

            EncryptingCredentials = new EncryptingCredentials(SymmetricKeyEncryptingCredentials,
                                    SecurityAlgorithms.Aes128KW,
                                    SecurityAlgorithms.Aes128CbcHmacSha256);
        }
    }
}