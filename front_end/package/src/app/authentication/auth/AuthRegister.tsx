'use client';
import React, { useState, useEffect } from 'react';
import { Box, Typography, Button } from '@mui/material';
import Link  from 'next/link';
import CustomTextField from '@/app/(DashboardLayout)/components/forms/theme-elements/CustomTextField';
import { Stack } from '@mui/system';
import axios from 'axios';
import { Snackbar, Alert } from '@mui/material';
import { useRouter } from 'next/navigation'
import { flushSync } from 'react-dom';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import AuthLogin from '@/app/authentication/auth/AuthLogin';


interface registerType {
    title?: string;
    subtitle?: JSX.Element | JSX.Element[];
    subtext?: JSX.Element | JSX.Element[];
  }
  
  const AuthRegister = ({ title, subtitle, subtext }: registerType) => {
    const [formData, setFormData] = useState({
      name: '',
      email: '',
      password: '',
    });
  
    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      setFormData({ ...formData, [e.target.id]: e.target.value });
    };
  
    const router = useRouter();

    const handleRegister = async () => {
      try {
        const response = await axios.post('https://localhost:7060/api/User/register', {
          fullName: formData.name,
          email: formData.email,
          password: formData.password,
        });
  
        // Hiển thị thông báo thành công
        toast.success('User registered successfully!', {
          position: 'top-right',
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });

        setTimeout(() => {
            router.push('/authentication/login');
          }, 500);
      } catch (error: any) {
        // Hiển thị thông báo lỗi
        toast.error(error.response?.data || 'Registration failed!', {
          position: 'top-right',
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });
      }
    };
  
    return (
      <>
        <ToastContainer />
        {title ? (
          <Typography fontWeight="700" variant="h2" mb={1}>
            {title}
          </Typography>
        ) : null}
  
        {subtext}
  
        <Box>
          <Stack mb={3}>
            <Typography
              variant="subtitle1"
              fontWeight={600}
              component="label"
              htmlFor="name"
              mb="5px"
            >
              Name
            </Typography>
            <CustomTextField
              id="name"
              variant="outlined"
              fullWidth
              value={formData.name}
              onChange={handleInputChange}
            />
  
            <Typography
              variant="subtitle1"
              fontWeight={600}
              component="label"
              htmlFor="email"
              mb="5px"
              mt="25px"
            >
              Email Address
            </Typography>
            <CustomTextField
              id="email"
              variant="outlined"
              fullWidth
              value={formData.email}
              onChange={handleInputChange}
            />
  
            <Typography
              variant="subtitle1"
              fontWeight={600}
              component="label"
              htmlFor="password"
              mb="5px"
              mt="25px"
            >
              Password
            </Typography>
            <CustomTextField
              id="password"
              variant="outlined"
              fullWidth
              type="password"
              value={formData.password}
              onChange={handleInputChange}
            />
          </Stack>
          <Button
            color="primary"
            variant="contained"
            size="large"
            fullWidth
            onClick={handleRegister}
          >
            Sign Up
          </Button>
        </Box>
        {subtitle}
      </>
    );
  };

export default AuthRegister;
