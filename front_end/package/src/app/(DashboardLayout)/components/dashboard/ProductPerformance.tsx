
import {
    Typography, Box,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Chip
} from '@mui/material';
import DashboardCard from '@/app/(DashboardLayout)//components/shared/DashboardCard';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';

import { flushSync } from 'react-dom';


// const products = [
//     {
//         id: "1",
//         name: "Sunil Joshi",
//         post: "Web Designer",
//         pname: "Elite Admin",
//         priority: "Low",
//         pbg: "primary.main",
//         budget: "3.9",
//     },
//     {
//         id: "2",
//         name: "Andrew McDownland",
//         post: "Project Manager",
//         pname: "Real Homes WP Theme",
//         priority: "Medium",
//         pbg: "secondary.main",
//         budget: "24.5",
//     },
//     {
//         id: "3",
//         name: "Christopher Jamil",
//         post: "Project Manager",
//         pname: "MedicalPro WP Theme",
//         priority: "High",
//         pbg: "error.main",
//         budget: "12.8",
//     },
//     {
//         id: "4",
//         name: "Nirav Joshi",
//         post: "Frontend Engineer",
//         pname: "Hosting Press HTML",
//         priority: "Critical",
//         pbg: "success.main",
//         budget: "2.4",
//     },
// ];


const ProductPerformance = () => {
    // const navigate = useNavigate();
    const [users, setUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    useEffect(() => {
        async function getAllUsers() {
            setIsLoading(true)
            debugger
            axios.get(`https://localhost:7060/api/User`)
                .then(response => {
                    setIsLoading(false)
                    setUsers(response.data);
                })
                .catch(error => {
                    setIsLoading(false)
                    console.error('There was an error fetching the Users!', error);
                });
        }
        getAllUsers();
    }, [
    ]);
    if (isLoading == true) {
        return <div>
            <h1>Data is loading</h1>
        </div>
    }
    return (

        <DashboardCard title="List User">
            <Box
                sx={{
                    maxHeight: '400px', // Giới hạn chiều cao (khoảng đủ cho 6 hàng)
                    overflowY: 'auto',  // Kích hoạt thanh cuộn dọc
                    overflowX: 'hidden', // Ẩn thanh cuộn ngang (nếu có)
                    width: { xs: '280px', sm: 'auto' },
                }}
            >
                {users.length > 0 ? (
                    <>
                        <Table
                            aria-label="simple table"
                            sx={{
                                whiteSpace: "nowrap",
                                mt: 2,
                            }}
                        >
                            <TableHead>
                                <TableRow>
                                    <TableCell>
                                        <Typography variant="subtitle2" fontWeight={600}>
                                            Id
                                        </Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography variant="subtitle2" fontWeight={600}>
                                            Assigned
                                        </Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography variant="subtitle2" fontWeight={600}>
                                            Name
                                        </Typography>
                                    </TableCell>
                                    <TableCell align="right">
                                        <Typography variant="subtitle2" fontWeight={600}>
                                            Budget
                                        </Typography>
                                    </TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {users.map((user) => {
                                    const { userId, fullName, email, balance } = user;
                                    return (
                                        <TableRow key={userId}>
                                            <TableCell>
                                                <Typography
                                                    sx={{
                                                        fontSize: "15px",
                                                        fontWeight: "500",
                                                    }}
                                                >
                                                    {userId}
                                                </Typography>
                                            </TableCell>
                                            <TableCell>
                                                <Box
                                                    sx={{
                                                        display: "flex",
                                                        alignItems: "center",
                                                    }}
                                                >
                                                    <Box>
                                                        <Typography variant="subtitle2" fontWeight={600}>
                                                            {email}
                                                        </Typography>
                                                    </Box>
                                                </Box>
                                            </TableCell>
                                            <TableCell>
                                                <Typography
                                                    color="textSecondary"
                                                    variant="subtitle2"
                                                    fontWeight={400}
                                                >
                                                    {fullName}
                                                </Typography>
                                            </TableCell>
                                            <TableCell align="right">
                                                <Typography variant="h6">${balance}</Typography>
                                            </TableCell>
                                        </TableRow>
                                    );
                                })}
                            </TableBody>
                        </Table>
                    </>
                ) : (
                    <p>No data found</p>
                )}
            </Box>
        </DashboardCard>

    );
};

export default ProductPerformance;
