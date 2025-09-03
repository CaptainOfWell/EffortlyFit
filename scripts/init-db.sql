-- Enable UUID extension
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Create schema
CREATE SCHEMA IF NOT EXISTS effortly;

-- Set default search path
SET search_path TO effortly, public;

-- Initial table setup will be handled by Entity Framework migrations
-- This file is for any initial database configuration
