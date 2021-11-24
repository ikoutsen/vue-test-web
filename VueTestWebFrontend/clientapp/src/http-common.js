import axios from 'axios';

export default axios.create({
    baseURL: 'http://localhost:22748/api',
    headers: {
        'Content-type': 'application/json'
    }
});