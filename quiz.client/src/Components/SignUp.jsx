//import React from 'react'
//import { ToastContainer, toast } from "react-toastify";
//import "react-toastify/dist/ReactToastify.css";
//import * as Yup from "yup";
//import { Button, TextField } from "@mui/material";
//import { useFormik } from "formik";
//import { Link, useNavigate } from "react-router-dom";
//import '../Login/Login.css'

//const initialValue = {
//    name:"",
//    email: "",
//    password: "",
//  };
//function Signup() {
//  const navigate = useNavigate();

//    const validationSchema = Yup.object().shape({
//        email: Yup.string().email().required("Enter Your Email"),
//        password: Yup.string().required("Enter Your Password"),
//      });

//  const onSubmit = (values)=>{
//    console.log(values)
//  }
//    const formik = useFormik({
//        initialValues: initialValue,
//        validationSchema: validationSchema,
//        onSubmit: onSubmit,
//      });
    
//      const { values, errors, touched, handleSubmit } = formik;
//  return (
//    <>
//        <ToastContainer className="toast-container" position="top-center" />
//            <div className="login-page">
//                <div className="container">
//                    <div className="login-contain  mx-auto">
//                        <div className="login-hading">
//                            <div className="logo pb-4">
//                                 {/* <img src={logo} alt="" className="img-fluid" /> */}
//                            </div>
//                            <h5>Sign Up In Your Account</h5>
//                        </div>
//                        <form action="" onSubmit={handleSubmit}>
//                        <div className="Name mt-4">
//                                <TextField
//                                    name="name"
//                                    variant="filled"
//                                    color="success"
//                                    placeholder="Enter Your Name"
//                                    label="Name"
//                                    value={values.name}
//                                    fullWidth
//                                    type="text"
//                                    onChange={formik.handleChange}
//                                    helperText={touched.name && errors.name}
//                                    error={touched.name && errors.name}
//                                />
//                            </div>
//                            <div className="Email mt-4">
//                                <TextField
//                                    name="email"
//                                    variant="filled"
//                                    color="success"
//                                    placeholder="Enter Your Email"
//                                    label="Email"
//                                    value={values.email}
//                                    fullWidth
//                                    type="text"
//                                    onChange={formik.handleChange}
//                                    helperText={touched.email && errors.email}
//                                    error={touched.email && errors.email}
//                                />
//                            </div>

//                            <div className="Password mt-4">
//                                <TextField
//                                    name="password"
//                                    placeholder="Enter Your Password"
//                                    label="Password"
//                                    variant="filled"
//                                    color="success"
//                                    value={values.password}
//                                    fullWidth
//                                    type="text"
//                                    onChange={formik.handleChange}
//                                    helperText={touched.password && errors.password}
//                                    error={touched.password && errors.password}
//                                />
//                            </div>
//                            <div className='d-flex justify-content-end mt-1 '>
//                                <Link to="/" className='text-decoration-none myfont'> <span className='text-dark'>Already have an account ? </span> Login</Link>
//                            </div>
//                            <div className="button mt-3">
//                                <Button variant="contained" color="success" type="submit">
//                                    SIGN UP
//                                </Button>
//                            </div>
//                        </form>
//                    </div>
//                </div>
//            </div>
//    </>
//  )
//}

//export default Signup;