\c template1
SELECT 'CREATE DATABASE luna'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'luna')
\gexec
