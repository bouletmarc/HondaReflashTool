using System;


internal class Class_ODB
{

    public Class_ODB()
    {
    }

    public enum Mode : byte
    {
        DIAGNOSTIC_SESSION_CONTROL         = 0x10,
        ECU_RESET                          = 0x11,
        SECURITY_ACCESS                    = 0x27,
        COMMUNICATION_CONTROL              = 0x28,
        TESTER_PRESENT                     = 0x3E,
        ACCESS_TIMING_PARAMETER            = 0x83,
        SECURED_DATA_TRANSMISSION          = 0x84,
        CONTROL_DTC_SETTING                = 0x85,
        RESPONSE_ON_EVENT                  = 0x86,
        LINK_CONTROL                       = 0x87,
        READ_DATA_BY_IDENTIFIER            = 0x22,
        READ_MEMORY_BY_ADDRESS             = 0x23,
        READ_SCALING_DATA_BY_IDENTIFIER    = 0x24,
        READ_DATA_BY_PERIODIC_IDENTIFIER   = 0x2A,
        DYNAMICALLY_DEFINE_DATA_IDENTIFIER = 0x2C,
        WRITE_DATA_BY_IDENTIFIER           = 0x2E,
        WRITE_MEMORY_BY_ADDRESS            = 0x3D,
        CLEAR_DIAGNOSTIC_INFORMATION       = 0x14,
        READ_DTC_INFORMATION               = 0x19,
        READ_DTC_BY_STATUS                 = 0x18,
        INPUT_OUTPUT_CONTROL_BY_IDENTIFIER = 0x2F,
        ROUTINE_CONTROL                    = 0x31,
        REQUEST_DOWNLOAD                   = 0x34,
        REQUEST_UPLOAD                     = 0x35,
        TRANSFER_DATA                      = 0x36,
        REQUEST_TRANSFER_EXIT              = 0x37,
        DIAGNOSTIC_COMMAND                 = 0xB1,
        UNKNOWN                            = 0xFF
    }

    public enum Enum0 : byte
    {
        NO_RESPONSE,
        POSTIVE_RESPONSE = 0x40,
        NEGATIVE_RESPONSE = 0x7F
    }

    public enum NegativeResponse : byte
    {
        POSITIVE_RESPONSE,
        GENERAL_REJECT = 16,
        SERVICE_NOT_SUPPORTED,
        SUBFUNCTION_NOT_SUPPORTED,
        INCORRECT_MSG_LENGTH_OR_FORMAT,
        RESPONSE_TOO_LONG,
        BUSY = 33,
        CONDITIONS_NOT_CORRECT,
        REQUEST_SEQUENCE_ERROR = 36,
        NO_RESPONSE_FROM_SUBCOMPONENT,
        FAILURE_PREVENTS_REQUESTED_ACTION,
        REQUEST_OUT_OF_RANGE = 49,
        SECURITY_ACCESS_DENIED = 51,
        INVALID_SECURITY_KEY = 53,
        SECURITY_ATTEMPS_EXCEEED,
        REQUIRED_TIME_DELAY_NOT_EXPIRED,
        UPLOAD_DOWNLOAD_NOT_ACCEPTED = 112,
        TRANSFER_DATA_SUSPENDED,
        GENERAL_PROGRAMMING_FAILURE,
        WRONG_BLOCK_SEQUENCE_COUNTER,
        REPONSE_PENDING = 120,
        INVALID_DATA_BLOCK,
        SUBFUNCTION_NOT_SUPPORTED_IN_ACTIVE_SESSION = 126,
        SERVICE_NOT_SUPPORTED_IN_ACTIVE_SESSION,
        RPM_TOO_HIGH = 129,
        RPM_TOO_LOW,
        ENGINE_IS_RUNNING,
        ENGINE_IS_NOT_RUNNING,
        ENGINE_RUN_TIME_TOO_LOW,
        TEMPERATURE_TOO_HIGH,
        TEMPERATURE_TOO_LOW,
        VEHICLESPEED_TOO_HIGH,
        VEHICLESPEED_TOO_LOW,
        THROTTLE_PEDAL_TOO_HIGH,
        THROTTLE_PEDAL_TOOL_LOW,
        TRANSMISSION_RANGE_NOT_IN_NEUTRAL,
        TRANSMISSION_RANGE_NOT_IN_GEAR,
        BRAKE_PEDAL_NOT_PRESSED_OR_NOT_APPLIED = 143,
        SHIFTER_LEVER_NOT_IN_PARK,
        TORQUE_CONVERTER_CLUTCH_LOCKED,
        VOLTAGE_TOO_HIGH,
        VOLTAGE_TOO_LOW,
        UNKNOWN = 255
    }

    public enum Enum1 : byte
    {
        TEST_FAILED_THIS_OPERATION_CYCLE = 2,
        PENDING_DTC = 4,
        CONFIRMED_DTC = 8,
        TEST_NOT_COMPLETED_SINCE_LAST_CLEAR = 16,
        TEST_FAILED_SINCE_LAST_CLEAR = 32,
        TEST_NOT_COMPLETED_THIS_OPERATION_CYCLE = 64,
        WARNING_INDICATOR_REQUESTED = 128
    }
}
