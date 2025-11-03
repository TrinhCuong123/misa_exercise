<template>
  <div class="main-title justify-space-between d-flex">
    <div class="main-title-left">Ứng viên</div>
    <div class="main-title-right">
      <div class="btn-create-employee d-flex align-center" @click="openModal">
        <div class="btn-left d-flex align-center">
          <div class="btn-left-icon icon icon-plus"></div>
          <div class="btn-left-title">Thêm ứng viên</div>
        </div>
        <div class="btn-right icon icon-down"></div>
      </div>
    </div>
  </div>
  <div class="main-table flex1">
    <div class="main-table-header d-flex justify-end align-center">
      <!-- <div class="table-header-input">
        <div class="header-input-right icon icon-search"></div>
        <input type="text" placeholder="Tìm kiếm nhanh trong danh sách" />
      </div> -->
      <MsInput icon="icon-search" v-model="search" placeholder="Tìm kiếm nhanh trong danh sách" />
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-filter"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-out"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-quickactive"></div>
      </div>
      <div class="d-flex justify-center align-center table-header-btn">
        <div class="icon icon-settings"></div>
      </div>
    </div>
    <ms-table :candidate-data></ms-table>
    <!-- <div class="main-table-body">
      <table>
        <thead>
          <tr>
            <th><input type="checkbox" /></th>
            <th>Họ và tên</th>
            <th>Số điện thoại</th>
            <th>Email</th>
            <th>Chiến dịch tuyển dụng</th>
            <th>Vị trí tuyển dụng</th>
            <th>Tin Tuyển dụng</th>
            <th>Vòng tuyển dụng</th>
            <th>Đánh giá</th>
            <th>Ngày tuyển dụng</th>
            <th>Nguồn Ứng viên</th>
            <th>Trình độ đào tạo</th>
            <th>Nơi đào tạo</th>
            <th>Chuyên ngành</th>
            <th>Nơi làm việc gần đây</th>
            <th>Đơn vị sử dụng</th>
            <th>Phù Hợp với chân dung</th>
            <th>Khu vực</th>
            <th>Người giới thiệu</th>
            <th>Thông tin tiếp nhận</th>
            <th>Thuộc kho tiềm năng</th>
            <th>Tài khoản cổng ứng viên</th>
            <th>Thẻ</th>
            <th>Trạng thái</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Địa chỉ</th>
            <th>Lý do loại</th>
            <th>Cộng tác viên</th>
            <th>Ngày tiếp nhận</th>
            <th>Trạng thái mời nhận việc</th>
          </tr>
        </thead>
        <tbody>
          <tr class="data-row" v-for="(candidate, index) in candidateData" :key="index">
            <td><input type="checkbox"></td>
            <td>
              <div class="name-with-avatar d-flex align-center">
                <div class="">
                  <div class="avatar-circle" :style="{ backgroundColor: candidate.AvatarColor || '#ccc' }">
                    {{ generateAvatar(
                      candidate.CandidateName
                    ) }}
                  </div>
                </div>
                <div>{{ checkNull(candidate.CandidateName) }}</div>
              </div>
            </td>
            <td>{{ checkNull(candidate.Mobile) }}</td>
            <td>{{ checkNull(candidate.Email) }}</td>
            <td>{{ checkNull(candidate.RecruitmentCampaignNames) }}</td>
            <td>{{ checkNull(candidate.JobPositionName) }}</td>
            <td>{{ checkNull(candidate.RecruitmentName) }}</td>
            <td>{{ checkNull(candidate.RecruitmentRoundName) }}</td>
            <td>{{ checkNull(candidate.Score) }}</td>
            <td>{{ formatDate(candidate.ApplyDate) }}</td>
            <td>{{ checkNull(candidate.ChannelName) }}</td>
            <td>{{ checkNull(candidate.EducationDegreeName) }}</td>
            <td>{{ checkNull(candidate.EducationPlaceName) }}</td>
            <td>{{ checkNull(candidate.EducationMajorName) }}</td>
            <td>{{ checkNull(candidate.WorkPlaceRecent) }}</td>
            <td>{{ checkNull(candidate.OrganizationUnitName) }}</td>
            <td>{{ checkNull(candidate.Overall) }}</td>
            <td>{{ checkNull(candidate.AreaName) }}</td>
            <td>{{ checkNull(candidate.PresenterName) }}</td>
            <td>{{ checkProbationInfoStatus(
              candidate.ProbationInfoStatus
            ) }}</td>
            <td>{{ checkIsTalentPoolDetail(
              candidate.IsTalentPoolDetail
            ) }}</td>
            <td>{{ checkNull(candidate.AccountPortal) }}</td>
            <td>{{ checkNull(candidate.TagInfos) }}</td>
            <td>{{ checkNull(candidate.CandidateStatusName) }}</td>
            <td>{{ formatGender(candidate.Gender) }}</td>
            <td>{{ formatDate(candidate.Birthday) }}</td>
            <td>{{ checkNull(candidate.Address) }}</td>
            <td>{{ checkNull(candidate.ReasonRemoved) }}</td>
            <td>{{ checkNull(candidate.CollaboratorName) }}</td>
            <td>{{ formatDate(candidate.HireDate) }}</td>
            <td>{{ formatOfferStatus(candidate.OfferStatus) }}</td>
            <td class="action-cell">
              <div class="action-buttons d-flex">
                <button class="btn-edit" aria-label="Sửa">
                  <div class="icon__right icon icon-update"></div>
                </button>
                <button class="btn-delete" aria-label="Xóa">
                  <div class="icon__right icon icon-delete"></div>
                </button>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div> -->
    <!-- <div class="main-table-footer d-flex justify-space-between">
      <div class="footer-sum-record">Tổng: <b>{{ sumRecord }}</b> bản ghi</div>
      <div class="footer-pagging">Số bản ghi/trang</div>
    </div> -->
  </div>
  <popup-candidate v-if="isOpenModal" @close-modal=closeModal @active-toast="activeToast" />
  <toast-candidate v-show="isActiveToast" state-toast="success" header-toast="Thông tin" content-toast="Thông báo!" />
</template>
<script setup>
import { ref } from 'vue';
import PopupCandidate from '@/views/candidate/form/MsPopupCandidate.vue';
import MsInput from '@/components/ms-input/MsInput.vue';
import MsTable  from '@/components/ms-table/ms-table.vue';
import { pushDataCandidate } from '@/services/fetchCandidate.js';
import ToastCandidate from '@/components/ms-toast/MsToast.vue';

const candidateData = pushDataCandidate();
const isActiveToast = ref(false);
const search = ref('');
const isOpenModal = ref(false);
const activeToast = () => {
  isActiveToast.value = true;
  setTimeout(() => {
    isActiveToast.value = false;
  }, 2000);
};
const openModal = () => {
  isOpenModal.value = true;
};
const closeModal = () => {
  isOpenModal.value = false;

};

</script>

<style scoped>
.main-title {
  height: 30px;
}

.main-title-left {
  font-size: 20px;
  font-weight: bold;
}

.main-table {
  background-color: #ffffff;
  display: flex;
  flex-direction: column;
  margin: 24px 0;
}

.main-table-header {
  /* gap: 8px; */
  padding: 16px 0;
  height: 50px;
}

.table-header-btn {
  width: 30px;
  height: 30px;
  border: 1px solid #e0e6ec;
  border-radius: 5px;
}

.main-table-header {
  gap: 10px;
  padding: 0 10px;
}

.main-table-header .icon {
  /* padding: 5px; */
  border: 8px solid #7a8188;
}

.btn-create-employee {
  background-color: #0078d4;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 14px;
}

.btn-create-employee .btn-left {
  gap: 8px;
  border-right: 0.5px solid #176cd1;
  padding: 8px 16px;
}

.btn-create-employee .btn-right {
  margin: 0 10px;
}
</style>