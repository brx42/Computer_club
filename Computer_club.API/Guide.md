# Create RsaKeys
>>>>> Открыть Git Bash и ввести следующие команды:
#
#### openssl req -x509 -newkey rsa:4096 -sha256 -nodes -keyout .{your path and file name}.key -out .{your path and file name}.crt -subj "/CN={your domen}" -days 3650
#
#### openssl pkcs12 -export -out {your file name}.pfx -inkey {your file name}.key -in {your file name}.crt -certfile {your file name}.crt
#
#### openssl pkcs12 -in {your file name}.pfx -nodes -out {your file name}.pem
#
#### openssl rsa -in {your file name}.pem -outform PEM -RSAPublicKey_out -out {your file name}.pub
#
