import Vue from 'vue'
import App from './App.vue'
import router from './router'
import 'bootstrap/dist/css/bootstrap.min.css'
import moment from 'moment';

Vue.config.productionTip = false
Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('DD.MM.YYYY');
    }
});


new Vue({
    el: '#app',
    router,
    template: '<App/>',
    components: { App }
})